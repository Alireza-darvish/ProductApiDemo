# Introduction
Simple Web API Application 
 

# Authentication
Basic Authentication

Accepted credential:

Username: abc

Password: 123


# Endpoints
1. /products

query string paramaters: limit(int),page(int)

returus a json object which contains list of products. it accepts 'limit' and 'page' parameters for paganation

example: GET /products?page=2&limit=10 

2. /products/search

parameters: color(string),type(string),limit(int),page(int) 

filter the products by given parameters and returns the result as json object 

example: GET /products/search?color=Color1&Type=Type1&page=2&limit=10 