const path = require('path');

module.exports = {
  entry: {
    tinymce: { import: './src/js/tinymce/plugin.js', filename: 'umbraco/lib/tinymce/plugins/reoakotranslationdialog/plugin.min.js' },
    modal: { import: './src/js/modal/reoako.backoffice.js', filename: 'js/reoako.backoffice.js' }
  },
  output: {
    filename: '[filename]',
    path: path.resolve(__dirname, 'BornDigital.ReoAko/BornDigital.ReoAko.Umbraco/wwwroot/'),
  },
  mode: "production",
  module: {
    rules: [
      {
        test: /\.s?css$/i,
        use: ["style-loader", "css-loader", "sass-loader"],
      },
    ],
  },
};