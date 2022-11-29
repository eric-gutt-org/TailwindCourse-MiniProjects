/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/styles.css",
    "../Components/**/*.razor",
    "../Features/**/*.razor"
  ],
  theme: {
    fontFamily: {
      sans: ['Mulish', 'sans-serif'],
      mono: ['Rokkitt', 'monospace']
    },
    extend: {},
  },
  plugins: [],
}
