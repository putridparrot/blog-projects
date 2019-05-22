Steps to get VSCode able to build a minimal TypeScript 
application and run it, includes setting up tools.

1. Create a folder
2. Open Visual Code from folder
3. Run _yarn init --yes_ 
4. Run _tsc --init_ to create a default tsconfig.json
5. Change tsconfig.json entry _"target"_ to _"es6"_
6. Ctrl+Shift+B both _tsc: build_ and _tsc: watch_ should be available
7. Start without debugging and choose node.js
8. From Visual Code Debug | Add Configuration... choose node which creates .vscode/launch.json
9. If needed upgrade Typescript using _npm install -g typescript@latest_