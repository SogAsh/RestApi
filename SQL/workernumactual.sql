CREATE OR REPLACE VIEW public.workernumactual AS 
 SELECT ws.worker_id,
    TRIM(ws.worker_name) as worker_name,
    ws.worker_num
   FROM workernumstate ws 
     WHERE ws.worker_state is NULL;

ALTER TABLE public.workernumactual
  OWNER TO postgres;