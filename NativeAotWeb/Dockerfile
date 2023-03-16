FROM debian AS base
WORKDIR /app

EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80

COPY ./bin/Release/net7.0/linux-x64/ .

RUN apt-get update && apt-get install -y libicu67 curl iputils-ping && apt-get clean

RUN addgroup --group demoappbackend --gid 2001 \
    && useradd -rm -d /home/demoappbackend -s /bin/bash -g 2001 -G 2001 -u 1001 demoappbackend \
    && chown -R demoappbackend:demoappbackend /app

RUN chown demoappbackend:demoappbackend /app
USER demoappbackend:demoappbackend

CMD ["./NativeAotWeb"]
#ENTRYPOINT ["dotnet", "App.Backend.dll"]