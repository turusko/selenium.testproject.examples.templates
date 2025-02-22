# selenium.testproject.examples.templates

This is a template project for Selenium tests, I want to create a reusable resource project for my own work and to help others get started with Selenium testing.

# Goals I am aiming for:
- [ ] Create a reusable project that can be used as a template for Selenium tests
- [x] Have drivers for Chrome, Firefox, and Edge
- [ ] Have drivers for remote and local testing
- [ ] Have a way to run tests in parallel
- [ ] Have a way to run tests in a CI/CD pipeline

# How to use this project:
Currently, this project is a work in progress and is not ready for use. I will update this README when the project is ready for use.


# Why are you not using specflow?
Specflow as far as i am aware (I can be wrong) is no longer supported and as we are using .net 8 i have moved away from using a pure BDD framework and moved back to xunit. 

I've not planned out everything as i imagine this will be a work in progress for a while.But i do hope you are able to use this project as a template for your own work.

# Enviroment Varibles
On windows if you want to run in headless mode set the enviroment "Headless" varible to true

`setx Headless true -m`

Just a note, you may have to restart Visual studio for the enviroment varible to take effect. Ideally when doing a CI/CD pipeline you would set this in the pipeline itself.