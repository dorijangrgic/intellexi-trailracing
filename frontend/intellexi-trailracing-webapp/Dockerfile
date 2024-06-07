# Stage 1: Build the Angular application
FROM node:20.14.0-bullseye AS build

# Set the working directory in the container
WORKDIR /app

# Install Angular CLI globally
RUN npm install -g @angular/cli@17.3.8

# Copy package.json to the working directory
COPY package.json ./

# Install the project dependencies
RUN npm install

# Copy the rest of the application code to the working directory
COPY . .

# Build the Angular application
RUN ng build --configuration production

# Stage 2: Serve the Angular application using a lightweight web server
FROM nginx:alpine

# Copy the build output from Stage 1 to the Nginx HTML directory
COPY --from=build /app/dist/intellexi-trailracing-webapp/browser /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]
