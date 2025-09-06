// fn main() -> Result<(), Box<dyn std::error::Error>> {
//     tonic_prost_build::configure()
//         .build_server(true)
//         .build_client(true)
//         .out_dir("src/generated")
//         .compile_protos(&["proto/hello.proto"], &["proto"])?;
//
//     println!("cargo:rerun-if-changed=proto/hello.proto");
//     Ok(())
// }

use std::arch::is_aarch64_feature_detected;
use tonic_prost_build::configure;

fn main() -> Result<(), Box<dyn std::error::Error>> {
    configure()
        // .build_server(true)
        // .build_client(true)
        .out_dir("src/generated")
        .compile_protos(&["proto/hello.proto"], &["proto"])
        .unwrap();
    Ok(())
}