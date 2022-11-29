/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/styles.css",
    "../Components/**/*.razor",
    "../Features/**/*.razor"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
