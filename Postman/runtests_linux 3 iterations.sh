cd ..

newman run Postman/dex.postman_collection.json -e Postman/local.postman_environment.json -k --silent -n 3

$SHELL