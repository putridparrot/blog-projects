module.exports =  {
    parser:  '@typescript-eslint/parser',  // Specifies the ESLint parser
    plugins: [
      '@typescript-eslint',
      'prettier'
    ],
    extends:  [
      'plugin:react/recommended',  // Uses the recommended rules from @eslint-plugin-react
      'plugin:@typescript-eslint/recommended',  // Uses the recommended rules from @typescript-eslint/eslint-plugin
      'airbnb-typescript',
      'prettier',
      'plugin:prettier/recommended'
    ],
    parserOptions:  {
        ecmaVersion:  2018,  // Allows for the parsing of modern ECMAScript features
        sourceType:  'module',  // Allows for the use of imports
        ecmaFeatures:  {
        jsx:  true,  // Allows for the parsing of JSX
        },
    },
    rules:  {
        '@typescript-eslint/interface-name-prefix': 'warn',
        'prettier/prettier': 'error'
    },
    settings:  {
      react:  {
        version:  'detect',  // Tells eslint-plugin-react to automatically detect the version of React to use
      },
    },
  };
