FROM mcr.microsoft.com/dotnet/sdk:7.0 AS dotnet-builder
RUN mkdir /app
WORKDIR /app
COPY . /app

RUN dotnet restore src/Api/Api.csproj -nowarn:msb3202,nu1503
RUN dotnet build   src/Api/Api.csproj -c Release -o /app/publish
RUN dotnet publish src/Api/Api.csproj -c Release -o /app/publish

# RUN dotnet test src/EscalaDePlantao.Tests/EscalaDePlantao.Tests.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime	
ENV ASPNETCORE_URLS=http://*:5183 \
	TZ=America/Campo_Grande 

WORKDIR /app 
EXPOSE 5183 
COPY --from=dotnet-builder /app/publish .
CMD ["dotnet", "Api.dll"]