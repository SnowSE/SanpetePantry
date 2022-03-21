# Sanpete Pantry

## Config & Setup Notes
- Logged in as root:
    - `apt install docker.io`
    - `apt install docker-compose`
    - `apt install snap`
    - `useradd -m -g users pantry`
    - `passwd pantry`
    - `sudo usermod -aG docker pantry`
    - `systemctl start docker`
    - `systemctl enable docker`
    - `sudo snap install powershell --classic`
    - edit /etc/ssh/sshd_config, add line `AllowUsers pantry`
- Restart your shell, log in as pantry
    - `docker run hello-world` (just to test things out and make sure docker is running)
    - `docker ps` (make sure you're in the docker user group)
    - `mkdir /home/pantry/scripts`
- Now you're ready to have the GitHub action deploy to the server.

[Workflow File](.github/workflows/main.yml)
