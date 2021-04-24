# CertbotAliyunDns
[![CI](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/CI.yml/badge.svg)](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/CI.yml)
[![Docker](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/Docker.yml/badge.svg)](https://github.com/HMBSbige/CertbotAliyunDns/actions/workflows/Docker.yml)
[![Docker](https://img.shields.io/badge/certbot--aliyundns-blue?label=Docker&logo=docker)](https://github.com/users/HMBSbige/packages/container/package/certbot-aliyundns)
[![Github last commit date](https://img.shields.io/github/last-commit/HMBSbige/CertbotAliyunDns.svg?label=Updated&logo=github)](https://github.com/HMBSbige/CertbotAliyunDns/commits)

# Usage
## Docker
### 拉取/更新最新镜像
```
docker pull ghcr.io/hmbsbige/certbot-aliyundns
```
### 测试运行
```
docker run \
-it \
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
-it \
--rm \
-v /etc/letsencrypt:/etc/letsencrypt \
ghcr.io/hmbsbige/certbot-aliyundns \
renew \
--manual --preferred-challenges dns \
--manual-auth-hook "/app/CertbotAliyunDns add $AccessKeyId $AccessKeySecret && sleep 25" \
--manual-cleanup-hook "/app/CertbotAliyunDns delete $AccessKeyId $AccessKeySecret"
```
