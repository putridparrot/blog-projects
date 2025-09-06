use env_logger::{Builder, Env};
use log::{info, warn, error, trace, debug, LevelFilter, log};

fn main() {

    // use env variable RUST_LOG=trace or in code, below
    // let env = Env::default().filter_or("RUST_LOG", "trace");
    // Builder::from_env(env).init();
    //env_logger::init();

    Builder::new()
        .filter_level(LevelFilter::Trace)
        .init();

    debug!("Debug log message");
    trace!("Trace log message");
    info!("Info log message");
    warn!("Warning log message");
    error!("Error log message");
}
