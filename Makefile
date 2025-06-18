.PHONY: restore build run watch test clean publish \
        tool-manifest install-ef user-secrets-init ef-update \
        format lint migrations


## Básico -----------------------------------------------------------

build: 
	docker compose up -d --build

migrations:
	dotnet ef migrations add $(name)


migrations-build:
	dotnet ef database update

drop-database:
	dotnet ef database drop

clean:
	@dotnet clean

## Ferramentas & banco ---------------------------------------------
tool-manifest:
	@dotnet new tool-manifest            # cria .config/dotnet-tools.json local

install-ef:
	@dotnet tool install dotnet-ef       # instala Entity Framework CLI

user-secrets-init:
	@dotnet user-secrets init            # habilita segredos de desenvolvimento

ef-update:
	@dotnet ef database update           # aplica migrations ao banco

## Qualidade opcional ----------------------------------------------
format:
	@dotnet format                        # formata código

lint:
	@dotnet build -warnaserror            # trata warnings como erros