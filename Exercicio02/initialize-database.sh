#!/bin/bash
 sleep 10 && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /home/setup.sql