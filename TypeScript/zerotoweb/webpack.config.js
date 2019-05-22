const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const MinifyPlugin = require("babel-minify-webpack-plugin");
const TerserPlugin = require('terser-webpack-plugin');

module.exports = {
  mode: 'development',
  entry: {
    app: './public/index.js'
  },
  //devtool: 'inline-source-map',
  devServer: {
    port: 9000,
    contentBase: './dist'
  },
  optimization: {
    minimizer: [new TerserPlugin({
      extractComments: true,
      test: /\.js(\?.*)?$/i,
    })],
  },
  plugins: [
    new CleanWebpackPlugin(),
    new HtmlWebpackPlugin({
      title: 'Demo'
    }),
    new MinifyPlugin()
  ],
  output: {
    filename: '[name].bundle.js',
    path: path.resolve(__dirname, 'dist'),
    publicPath: '/'
  }
};
