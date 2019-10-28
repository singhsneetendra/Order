#!/bin/bash - 
#===============================================================================
#
#          FILE: start_app.sh
# 
#         USAGE: ./start_app.sh 
# 
#   DESCRIPTION: 
# 
#       OPTIONS: ---
#  REQUIREMENTS: ---
#          BUGS: ---
#         NOTES: ---
#        AUTHOR: Neetendra Singh
#  ORGANIZATION: 
#       CREATED: 10/21/2019 13:25
#      REVISION:  ---
#===============================================================================

set -o nounset                              # Treat unset variables as an error

# Point to correct destincation setting for POST url instead of default localhost.
if [ -f /app/appsettings.json ] ; then 
	cp -pr /app/appsettings.json /app/appsettings.json.new
	sed -i "s/localhost/invoicesserver/" /app/appsettings.json.new
	cp -pr /app/appsettings.json.new /app/appsettings.json
else 
        echo "ERROR: file /app/appsettings.json not exist." && exit 1
fi

# Start application.
dotnet /app/Orders.dll
