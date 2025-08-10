import express, { Request, Response } from 'express';
import bodyParser from 'body-parser';

const app = express();
const PORT = process.env.PORT || 8080;

app.use(bodyParser.json());


app.get('/echo', (req: Request, res: Response) => {
  const queryParams = req.query;
  res.type('text/plain');
  res.send(`Node Echo: ${queryParams.text}`);
});

app.get('/livez', (_req: Request, res: Response) => {
  res.sendStatus(200);
});

app.get('/readyz', async (_req: Request, res: Response) => {
  try {
    res.sendStatus(200);
  } catch (err) {
    res.status(503).send('Service not ready');
  }
});

app.listen(PORT, () => {
  console.log(`Echo service is live at http://localhost:${PORT}`);
});