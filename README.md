# Order - Sample Web API (.NET Core ) to receive orders and send to Invoices api.

## Deploy and run with docker to initialize app along with invoices app.

#### checkout repos in some directories and test and build images, and intialize api's.
```
mkdir app
cd app/
git clone https://github.com/singhsneetendra/Order.git
git clone https://github.com/singhsneetendra/Invoice.git
cd Order
docker build --no-cache -t api/orders .
cd ../Invoice
docker build --no-cache -t api/invoices .
cd ../Order
docker-compose -f ./docker-compose.yml up -d 
```
access orders application at - http://localhost:80/swagger/index.html
access invoices applicatoin at http://localhost:8080/swagger/index.html

You can run post request to be sent from endpoint http://localhost:80/swagger/index.html and check if is added in database by qureying database OR accessing http://localhost:8080/swagger/index.html and making a get request to list those order. 

access database query to see data in orders table. 
```
mysql -uinvoice -pinvoice -hlocalhost invoices
select * from orders ;
```
