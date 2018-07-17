# Resistor OhmValue Calculator

This project contains UI and Api to build a tool for calculating Resitor OhmValue Calculator. UI is built using REACT and Api is built
using Asp.net Core.

- Api contains calculator logic.
- Web contains Ui.

## Prerequisites
- Visual Studio 2017
- Visual Studio Code
- Node.js from https://nodejs.org/en/

## Configuring and Initializing Api
- Configuring Api is the first step that need to be done
- Download the repository and go to folder "api" and open "OhmValueCalcApi.sln" and run the same. 
You will see swagger url i.e "http://localhost:57489/swagger/index.html" in the browser.
- With this Api is ready to consume.

## Configuring and Initializing UI (React)
- Using visual studio code open the folder "web" from your local repository.
- Go to terminal in visual studio and run below command
  "npm install"
- After successful installation of local node modules run below command
  "npm start"
- You will see local react webapp running

## Assumptions or Changes made to given challenge

- Instead of multiple parameters converted the same to one model parameter for the ease of 
applying validations and to avoid multiple parameters
- Also return type has been modified to return "resistance, maxvalueaftertolerance, minvalueaftertolerance".
