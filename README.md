![image](https://github.com/amhewagama/CoreRAT/assets/69456605/99610207-1ff2-473c-961a-e9d62c9a0f72)# CoreRAT

CoreRAT is a remote administration tool (RAT) for Windows, developed using VB.NET 2010. It offers a range of features designed to provide comprehensive remote control and monitoring capabilities.

![image](https://github.com/amhewagama/CoreRAT/assets/69456605/1a936633-0e24-4f33-afa6-d4435f024287)

## Features

- **Remote Desktop**: View and control the desktop of the remote machine.
- **File Manager**: Access and manage files on the remote system.
- **Task Manager**: Monitor and control running processes.
- **Installed Software**: View a list of software installed on the remote machine.
- **TCP Ports**: Check the status of TCP ports on the remote system.
- **Startup Manager**: Manage programs that run at startup.
- **Keylogger**: Capture keystrokes on the remote system.
- **View Thumbs**: View thumbnail previews of remote system images.
- **Server Options**: Restart or close the server remotely.
- **Small Server**: The server component is lightweight, with a size of only 40Kb.

## Getting Started

### Prerequisites

- Windows operating system
- .NET Framework (version compatible with VB.NET 2010)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/amhewagama/CoreRAT.git
    ```

2. Open the project in Visual Studio 2010 or later.

3. Build the solution to compile the server and client components.

### Usage

1. Launch the server on the target machine.
2. Use the client application to connect to the server by specifying the IP address and port.
3. Once connected, use the provided features to remotely administer the target machine.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Disclaimer

This tool is intended for legitimate administrative use only. Unauthorized use of this software to access and control systems without permission is illegal and unethical. Use responsibly.

## Contact

For questions or suggestions, feel free to open an issue or reach out to brmone9@gmail.com.

---

By using CoreRAT, you agree to abide by all relevant laws and regulations. The authors of this software do not assume any responsibility for misuse or damage caused by this software.

## Port mapping

Client port: 80
![image](https://github.com/amhewagama/CoreRAT/assets/69456605/ab52d83e-1ca0-426f-9b16-29e8ec39c3f6)

Server host: (yourid)-46831.portmap.host (193.161.193.99)
Server port : 46831

![image](https://github.com/amhewagama/CoreRAT/assets/69456605/58c4294a-b449-4600-82f8-3d466cba5a6a)


## Potmap.io setup
Download OpenVPN config
https://portmap.io/configs/create
Set Mapping rule
https://portmap.io/mappings
