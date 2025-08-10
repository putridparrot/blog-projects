npm init -y
npm install express body-parser
npm install --save-dev typescript ts-node @types/node @types/express
npx tsc --init

//

npx ts-node src/app.ts



kubectl apply -f .\deployment.yaml -n dev
kubectl delete -f .\deployment.yaml -n dev