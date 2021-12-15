FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic



RUN mkdir /app
WORKDIR /app
COPY . .
RUN dotnet publish "ChallengeCoodesh_CROM.csproj" -o /app/publish

RUN chmod 750 /app/publish

# Add crontab file in the cron directory
ADD crontab /etc/cron.d/hello-cron

# Give execution rights on the cron job
RUN chmod 0644 /etc/cron.d/hello-cron

# Create the log file to be able to run tail
RUN touch /var/log/cron.log

#Install Cron
RUN apt-get update
RUN apt-get -y install cron
RUN apt-get install nano

# Run the command on container startup
CMD cron && tail -f /var/log/cron.log
