FROM mcr.microsoft.com/mssql/server

ENV CHECK_POLICY=OFF
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Dev123456789
ENV MSSQL_PID=Developer

COPY "Exercicio02/" /home
COPY "Exercicio02/setup.sql" /home

ENTRYPOINT [ "/bin/bash", "/home/entrypoint.sh" ]
# CMD [ "/opt/mssql/bin/sqlservr" ]