use kube::{Api, Client};
use k8s_openapi::api::core::v1::Pod;
use kube::runtime::reflector::Lookup;

#[tokio::main]
async fn main() -> anyhow::Result<()> {
    let client = Client::try_default().await?;
    //let pods: Api<Pod> = Api::default_namespaced(client);
    let pods: Api<Pod> = Api::all(client);
    //let pods: Api<Pod> = Api::namespaced(client, "");


    let pod_list = pods.list(&Default::default()).await?;

    for p in pod_list {
        println!("Pod name: {:?}", p.name().expect("Pod name missing"));
    }

    Ok(())
}
