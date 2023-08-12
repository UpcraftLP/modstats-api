# ModStats API

https://mods.upcraft.dev/api/graphql



An API Server to keep track of historical download and version data across [Modrinth](https://modrinth.com) and [Curseforge](https://.curseforge.com).





## How to use

1. Set up a [PostgreSQL](https://hub.docker.com/_/postgres) database to connect the API to.

2. Simply download and run the docker container:

    ```sh
    docker pull ghcr.io/upcraftlp/modstats-api:latest
    ```

    An [example appsettings file](appsettings.Example.json) is provided to list all configuration values. Alternatively those can be supplied via environment variables. See the [ASP.NET Core documentation](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0) on configuration.



