# Sanpete Pantry

## Table of Contents

---

1. <a href="#introduction">Introduction</a>
2. <a href="#config">Config & Setup</a>

---

<div id="introduction"></div>

## Introduction

<img width="200" alt="logo" src="./SanpetePantry/wwwroot/img/Logo.webp" />

Sanpete Pantry is the Food Pantry for Sanpete County and is dedicated to eliminating hunger in Sanpete County. This is the repository for our public website: [Visit here](https://SanpetePantry.org)

<div id="config"></div>

## Config & Setup Notes
- Logged in as root:
    - `apt install docker.io`
    - `apt install docker-compose`
    - `apt install snapd`
    - `snap install core`
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