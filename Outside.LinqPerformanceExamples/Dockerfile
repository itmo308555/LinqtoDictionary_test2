#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:2.1-nanoserver-1903 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Outside.LinqPerformanceExamples/Outside.LinqPerformanceExamples.csproj", "Outside.LinqPerformanceExamples/"]
RUN dotnet restore "Outside.LinqPerformanceExamples/Outside.LinqPerformanceExamples.csproj"
COPY . .
WORKDIR "/src/Outside.LinqPerformanceExamples"
RUN dotnet build "Outside.LinqPerformanceExamples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Outside.LinqPerformanceExamples.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Outside.LinqPerformanceExamples.dll"]