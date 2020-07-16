# ReqresAPI
ReqresAPI project is used to test APIs in Visual Studio using RestSharp. This project covers small smoke tests of 4 following endpoints:
- GET: LIST USERS
- POST: REGISTER UNSUCCESSFUL
- DELETE: DELETE
- GET: DELAYED RESPONSE

# Table of Contents

- [Getting started](#getting-started)
- [Prerequisites](#prerequisites)
- [Importing the project](#importing-the-project)
- [Running the project](#running-the-tests)

## Description
This project covers testing of 4 endpoints, where each endpoint has its own test group that is presented as one Unit Test class with name of the endpoint that it tests. Test cases are grouped by endpoints. Each endpoint has set of test and those test cover smoke test group.

## Getting started
Following instructions will help you to set project up and run on your local machine for testing purposes.
### Prerequisites
To use import this project and run tests you need to have installed:
- Visual Studio Professional 2019 or
- Visual Studio Express 2019

## Importing the project
RestSharp Project needs to be imported in Visual Studio 2019. To do so, please follow next steps:
1. Download project from Github
2. Open Visual Studio 2019
2. Select File from menu
3. Select Open -> Project/Solution
4. Browse for project RestSharp that you previously downloaded from Github
5. Click on button Open

## Running the tests
To run the test in Visual Studio, following steps should be executed:
1. Select Test from main menu in Visual Studio
2. Select Test Explorer
3. In Solution Explorer right click on solution and select Build
4. In Test Explorer right click on test you want to run and select Run 
5. View results in Test Explorer

