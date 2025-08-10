FROM node:24-alpine

WORKDIR /app

COPY package.json package-lock.json* tsconfig.json ./

RUN npm install

COPY src ./src

#RUN npx tsc

EXPOSE 8080

CMD ["npx", "ts-node", "src/app.ts"]