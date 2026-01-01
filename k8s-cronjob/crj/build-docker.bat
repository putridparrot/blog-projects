docker build -t putridparrot/crj:1.0.0 .

docker tag putridparrot/crj:1.0.0 putridparrotacr.azurecr.io/putridparrot/crj:1.0.0

docker push putridparrotacr.azurecr.io/putridparrot/crj:1.0.0