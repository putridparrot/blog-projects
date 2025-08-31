FROM eclipse-temurin:21-jdk AS builder

WORKDIR /app

COPY . .
RUN ./mvnw clean package -DskipTests

FROM eclipse-temurin:21-jre AS runtime

WORKDIR /app

COPY --from=builder /app/target/echo-service.jar ./echo-service.jar

ENV PORT=8080
EXPOSE 8080

ENTRYPOINT ["java", "-jar", "echo-service.jar"]