CREATE OR REPLACE VIEW public.userrole AS 
 SELECT wn.value,
    ws.id_name,
    ws.param_name
   FROM object_params wn
     LEFT JOIN param_type ws ON ws.id = wn.param_id
     WHERE ws.id_name = 'PT_ROLETEMPLATE' 
     AND ws.param_name = 'Шаблон ролей прав';

ALTER TABLE public.userrole
  OWNER TO postgres;