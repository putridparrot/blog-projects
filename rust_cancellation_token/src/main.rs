use std::io;
use std::time::Duration;
use tokio_util::sync::CancellationToken;

#[tokio::main]
async fn main() -> anyhow::Result<()> {
    let token = CancellationToken::new();
    let child = token.child_token();

    let handle = tokio::spawn(async move {
        tokio::select! {
            _ = child.cancelled() => {
                println!("Child1 task cancelled");
            }
            _ = tokio::time::sleep(Duration::from_secs(30)) => {
                println!("Child2 task cancelled");
            }
        }
    });

    io::stdin().read_line(&mut String::new())?;
    token.cancel();

    handle.await.expect("Task panicked");
    println!("Task Completed");

    Ok(())
}
