FROM node:21-alpine3.18 as build

WORKDIR /usr/app
COPY . .
RUN npm install
RUN npm run build

FROM nginx:alpine
COPY --from=build /usr/app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]