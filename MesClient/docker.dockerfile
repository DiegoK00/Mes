# Client App
FROM johnpapa/angular-cli AS client-app
LABEL authors="John Papa"
WORKDIR /usr/src/app
COPY ["package.json", "npm-shrinkwrap.json*", "./"]
RUN npm install --silent
COPY . .
RUN ng build --configurations production

# Node server
FROM node:12-alpine AS node-server
WORKDIR /usr/src/app
COPY ["package.json", "npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent && mv node_modules ../
COPY *.js .
# COPY /server /usr/src/app/server
COPY /dist/mes-client  /usr/src/app/server

# Final image
FROM node:12-alpine
WORKDIR /usr/src/app
COPY --from=node-server /usr/src /usr/src
COPY --from=client-app /usr/src/app/dist ./
EXPOSE 4200
# CMD ["node", "server.js"]
CMD ["npm", "start"]

ENTRYPOINT ["ng", "API.dll"]
