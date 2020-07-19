FROM mcr.microsoft.com/mssql/server

USER root

ENV CHECK_POLICY=OFF
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Dev123456789
ENV MSSQL_PID=Developer

COPY "Exercicio02/" .

# Grant permissions for the import-data script to be executable
RUN chmod +x ./initialize-database.sh

USER mssql

# ENTRYPOINT [ "/bin/bash", "entrypoint.sh" ]
# CMD ["/opt/mssql/bin/sqlservr"]
ENTRYPOINT /bin/bash ./entrypoint.sh