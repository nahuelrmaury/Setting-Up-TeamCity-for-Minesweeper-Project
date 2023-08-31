# Setting Up TeamCity for Minesweeper Project

In this task, we will set up a local TeamCity server and agent to automate the build and testing process for the Minesweeper project. Additionally, we will publish the Core project as a NuGet package using TeamCity.

## Table of Contents
- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Setting Up TeamCity Server and Agent](#setting-up-teamcity-server-and-agent)
- [Creating a New Pipeline](#creating-a-new-pipeline)
- [Pipeline Steps](#pipeline-steps)
- [Conclusion](#conclusion)

## Introduction

The goal of this task is to automate the build and testing process for the Minesweeper project using TeamCity. We will create a local TeamCity server and agent, set up a pipeline that triggers on new commits, and configure the pipeline steps.

## Prerequisites

Before starting, ensure that you have the following prerequisites in place:
- Visual Studio or a compatible IDE for C# development.
- Minesweeper project with the following structure:
  - Core project
  - Console project
  - Tests project
- TeamCity Server and Agent installed locally.

## Setting Up TeamCity Server and Agent

1. Install TeamCity Server on your local machine. Follow the installation instructions provided in the TeamCity documentation.

2. Install TeamCity Agent on your local machine. Make sure the agent is configured to connect to the TeamCity Server.

3. Start both the TeamCity Server and Agent services.

4. Access the TeamCity web interface using your web browser (usually at http://localhost:8111) and complete the initial setup.

## Creating a New Pipeline

1. In the TeamCity web interface, create a new project for the Minesweeper project.

2. Inside the project, create a new build configuration for the Minesweeper project.

3. Configure the build configuration to use the VCS (Version Control System) where your Minesweeper project is hosted (e.g., Git).

## Pipeline Steps

Define the following pipeline steps:

1. **Build Solution**: Configure this step to build the Minesweeper solution.

2. **Run Unit Tests**: Configure this step to execute unit tests from the Tests project.

3. **Publish Core Project as NuGet Package**: This step involves publishing the Core project as a NuGet package. You can achieve this by using a script or tool (e.g., NuGet CLI).

4. **Artifact Publishing**: Configure TeamCity to publish the built artifacts to a designated location.

## Conclusion

By setting up TeamCity with a local server and agent, and creating a pipeline with the specified steps, you can automate the build, testing, and publishing process for the Minesweeper project. TeamCity will trigger the pipeline on new commits, ensuring that your project is built and tested consistently.
