CREATE OR REPLACE VIEW public.reportdesign AS 
 SELECT wn.value,
    ws.id_name,
    ws.param_name
   FROM object_params wn
     LEFT JOIN param_type ws ON ws.id = wn.param_id
     WHERE ws.id_name = 'PT_DESCRIPTION' 
     AND ws.param_name = 'Имя отчёта в интерфейсе';
ALTER TABLE public.reportdesign
  OWNER TO postgres;