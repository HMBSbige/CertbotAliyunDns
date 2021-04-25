# CertbotAliyunDns
[![CI](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/CI.yml/badge.svg)](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/CI.yml)
[![Docker](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/Docker.yml/badge.svg)](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/Docker.yml)
[![Docker](https://img.shields.io/badge/certbot--aliyundns-blue?label=Docker&logo=docker)](https://github.com/users/HMBSbige/packages/container/package/certbot-aliyundns)
[![Github last commit date](https://img.shields.io/github/last-commit/HMBSbige/CertbotAliyunDns.svg?label=Updated&logo=github)](https://github.com/HMBSbige/CertbotAliyunDns/commits)

# Usage
## 插件

在 [Actions](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/CI.yml?query=workflow%3ACI+branch%3Amaster+is%3Asuccess) 中选择最新的 Commit 下载所需平台的 Artifact

假设放到 `/etc/letsencrypt/renewal-hooks` 中

### 测试续签
```
certbot \
--server https://acme-v02.api.letsencrypt.org/directory \
renew \
--dry-run \
--manual --preferred-challenges dns \
--manual-auth-hook "/etc/letsencrypt/renewal-hooks/CertbotAliyunDns add $AccessKeyId $AccessKeySecret && sleep 25" \
--manual-cleanup-hook "/etc/letsencrypt/renewal-hooks/CertbotAliyunDns delete $AccessKeyId $AccessKeySecret" \
--deploy-hook "docker restart nginx"
```
## Docker
### 拉取/更新最新镜像
```
docker pull ghcr.io/hmbsbige/certbot-aliyundns
```
### 测试运行
```
docker run \
--rm \
-v /etc/letsencrypt:/etc/letsencrypt \
ghcr.io/hmbsbige/certbot-aliyundns \
certonly \
--dry-run \
-d *.example.com \
--manual \
--preferred-challenges dns \
--manual-auth-hook "/app/CertbotAliyunDns add $AccessKeyId $AccessKeySecret && sleep 25" \
--manual-cleanup-hook "/app/CertbotAliyunDns delete $AccessKeyId $AccessKeySecret"
```

### 续签所有证书
```
docker run \
--rm \
-v /etc/letsencrypt:/etc/letsencrypt \
ghcr.io/hmbsbige/certbot-aliyundns \
renew \
--manual --preferred-challenges dns \
--manual-auth-hook "/app/CertbotAliyunDns add $AccessKeyId $AccessKeySecret && sleep 25" \
--manual-cleanup-hook "/app/CertbotAliyunDns delete $AccessKeyId $AccessKeySecret"
```
