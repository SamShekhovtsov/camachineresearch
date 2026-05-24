FROM python:3.12-alpine

WORKDIR /app

RUN addgroup -S caweb && adduser -S caweb -G caweb

COPY index.html styles.css app.js README.md ./
COPY src ./src

USER caweb

EXPOSE 5174

CMD ["python", "-m", "http.server", "5174", "--bind", "0.0.0.0"]