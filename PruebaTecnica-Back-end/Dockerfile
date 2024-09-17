
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR prueba_tecnica

#PORT
EXPOSE 80
EXPOSE 8080

#COPY PROJECT FILES 
COPY ./*.csproj ./
RUN dotnet restore

#COPY EVERYHING ELSE

COPY . .
RUN dotnet publish -c Release -o out

#BUILD IMAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 
WORKDIR /prueba_tecnica
COPY --from=build /prueba_tecnica/out .
ENTRYPOINT ["dotnet", "PruebaTecnica-Back-end.dll"]
