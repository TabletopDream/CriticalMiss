FROM node:8.9-alpine as builder

WORKDIR /src
COPY package.json package-lock.json ./
RUN npm cache clean --force
RUN npm install 
RUN mkdir /ng-app 
RUN cp -R ./node_modules /ng-app

WORKDIR /ng-app
COPY . .
RUN $(npm bin)/ng build --prod --build-optimizer

# BUILD STAGE - Application deploy
FROM nginx:1.13.3-alpine

COPY nginx/default.conf /etc/nginx/conf.d/

RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /ng-app/dist /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]