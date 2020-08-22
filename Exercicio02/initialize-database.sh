#!/bin/bash
 echo antes && sleep 15 && echo depois && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /home/setup.sql