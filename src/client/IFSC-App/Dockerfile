FROM node:10.16.2

WORKDIR /

ENV PATH /node_modules/.bin:$PATH

COPY package.json /package.json
RUN npm install
RUN npm install -g @angular/cli@8.2.1

COPY . /

CMD ng serve --host 0.0.0.0