CREATE OR REPLACE VIEW public.username AS 
 SELECT wn.value,
	wn.obj_id,
    ws.id_name,
    ws.param_name
   FROM object_params wn
     LEFT JOIN param_type ws ON ws.id = wn.param_id
     WHERE ws.id_name = 'PT_LOGIN' 
     AND ws.param_name = 'Логин';

ALTER TABLE public.username
  OWNER TO postgres;