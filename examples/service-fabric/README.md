# Service Fabric Example

## Prerequisites

* A Service Fabric cluster up and running
  (either in [Azure](https://docs.microsoft.com/en-us/azure/service-fabric/tutorial-managed-cluster-deploy)
  or [locally](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-tutorial-standalone-create-service-fabric-cluster)).
* [sfctl](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-cli)

## Installing the app in your Service Fabric cluster

Begin by connecting your `sfctl` to your cluster:

```sh
sfctl cluster select --endpoint https://your-cluster.azureregion.cloudapp.azure.com:19080 --pem ./your-cluster-certificate.pem --no-verify
```

After that, run the simple installtion script:

```sh
./install-joke-central.sh
```

```sh
./install-otelcol.sh
```
