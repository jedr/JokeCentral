#!/bin/bash
set -e

export appName=JokeCentralApp

sfctl application delete --application-id ${appName}
sfctl application unprovision --application-type-name ${appName}Type --application-type-version 1.0.0
sfctl store delete --content-path ${appName}
