# Stop Web Crawlers Web Update API

A web API to enable updates the Stop Web Crawlers WordPress Plugin referer spam list


## Database 
We'll make use of MS SQL in a Docker container for the Database server 


[Run the SQL Server Docker image on Linux, Mac, or Windows](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup-docker)

   

# Download the docker image
 ```
        sudo docker pull microsoft/mssql-server-linux
  ```

# run docker image - we've set up a standard SA password
 ```
        docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssw0rd12' -p 1433:1433 -d microsoft/mssql-server-linux
  ```

 # Upgrade docker
  ```
        sudo docker pull microsoft/mssql-server-linux:latest
  ```
 # Connect and Query
 ```
      sqlcmd -S localhost -U SA -P P@ssw0rd12 
```
 # Check Database exists
  ```
 SELECT Name from sys.Databases;
GO
 ```




[![threenine logo](https://threenine.co.uk/wp-content/uploads/2016/12/threenine_footer.png)](https://threenine.co.uk/)
