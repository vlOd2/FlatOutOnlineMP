# FlatOutOnlineMP
Play FlatOut 1 over the internet via TCP

# Compatibility
Only officially tested with FlatOut 1.0 (EU), should work across all 1.x versions<br>
May also possibly work with FlatOut 2, but not officially tested or supported

# Usage
The host starts to listen and port forwards the listen port (or use tools like Ngrok)<br>
The players connect to the host<br>
The host starts streaming and starts the game (see below)<br>
All players start streaming and then start their game (see below)<br>

# Starting the game
You can either use the start game buttons on either side, or manually launch the game like so:
- Host: `flatout.exe -host -lan`
- Player: `flatout.exe -join=127.0.0.1:port -lan`
For players, the port is reported in the logs when you start streaming