# Introduction
Simple .Net Core Web API Application 

Framework: .Net Core 3.1

Data Access: Entity Framework Core (with Code First Approach)


# Authentication
<b>Basic Authentication</b>

Accepted credential:

* Username: abc

* Password: 123


# Endpoints
<b>1. /products</b>

* query string paramaters: limit(int),page(int)
  
* returus a json object which contains list of products. it accepts 'limit' and 'page' parameters for pagination 
 
* example: GET /products?page=2&limit=10 

<b>2. /products/search</b>

* query string parameters: color(string),type(string),limit(int),page(int) 

* filter the products by given parameters and returns the result as json object 

* example: GET /products/search?color=Color1&Type=Type1&page=2&limit=10 
