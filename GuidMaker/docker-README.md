# Running the image

This image expects to run with https, thereby you will need to map a local port to 443, as well as configure ports and certificates as indicated in [Hosting ASP.NET Core Images with Docker over HTTPS](https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/aspnetcore-docker-https.md).

An example:

```
docker run -it -p 4443:443 \
   -e ASPNETCORE_URLS="https://+443" \
   -e ASPNETCORE_Kestrel__Certificates__Default__Password="{YOUR CERTIFICATE PASSWORD}" \
   -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/{NAME OF YOUR PFX}.pfx \
   -v {PATH TO YOUR .pfx}:/https/ \
   --name guidmaker \
   legobuff/guidmaker
```

I created dev certs by:

```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/GuidMaker.pfx -p crypticpassword
dotnet dev-certs https --trust
```

and run the image by:

```
docker run -it -p 4443:443 \
   -e ASPNETCORE_URLS="https://+443" \
   -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" \
   -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/GuidMaker.pfx \
   -v ${HOME}/.aspnet/https:/https/ \
   --name guidmaker \
   legobuff/guidmaker
```
